"""Small example OSC server

This program listens to several addresses, and prints some information about
received packets.
"""

from __future__ import absolute_import, division, print_function, unicode_literals
import argparse
import math
import numpy as np
from pythonosc import dispatcher
from pythonosc import osc_server
from pythonosc import udp_client
import time
import _pickle as cPickle
import scipy
from scipy import stats, optimize, interpolate
import datetime

import os
import random

size = 0


filename = '4class_our8e_SVM_max.sav' #58%,6users
loaded_model = cPickle.load(open(filename, 'rb'))

num_electrodes = 8
num_users= 1 ###############
num_entries= num_users
input_ = np.full((1,8,8064), -1)
f= open("test_log.txt","w+")

#########################################
def delta(x,xlen):
  return ( np.sum(np.diff(x,n=1)) / (xlen - 1) )

def gamma(x,xlen):
  sum=0
  for i in range(0,xlen-2):
    sum += abs(x[i+2] - x[i])
  return ( sum / (xlen - 2) )


#################################

def six_stats(new_data):
  new_data_processed = np.empty([num_entries,num_electrodes,378]) # 6 * 63
  index = 0
  print("\nNew_data original shape:",new_data.shape)
  for i in range(0,num_entries):
    for j in range(0,num_electrodes):
      index = 0
      for k in range(0,8064,128):
        if k!=7936:
          chunk = new_data[i][j][k:k+512]
        else:
          chunk = new_data[i][j][k:8065]
        
        chunk_len = len(chunk)
        
        new_data_processed[i][j][index] = np.mean(chunk)
        index += 1
        
        chunk_stdev = np.std(chunk) * math.sqrt(chunk_len / (chunk_len-1))
        new_data_processed[i][j][index] = chunk_stdev
        index += 1
        #if(chunk_stdev == 0):
          #print("\nI AM ZERO!!")
          #print(k,i,j)
        chunk_delta = delta(chunk,chunk_len)
        new_data_processed[i][j][index] = chunk_delta
        index += 1
        
        new_data_processed[i][j][index] = chunk_delta / chunk_stdev
        index += 1
        
        chunk_gamma = gamma(chunk,chunk_len)
        new_data_processed[i][j][index] = chunk_gamma
        index += 1
        
        new_data_processed[i][j][index] = chunk_gamma / chunk_stdev
        index += 1
        
  return new_data_processed
   # print(index)
  
      




def print_handler(address, *args):

    global size
    global input_
    ele_8 = np.asarray(args)

    if(size != 8064):
      if( not np.array_equal(ele_8 , np.zeros(8)) ):
        input_[0,:,size] = ele_8
        size += 1
    
    if(size == 8064):
      size = 0
      print(input_[0][0])
      print("\nIN")
      processed = six_stats(input_)
      print("\nProcessed:",processed.shape) #should be 8 X 378
      reshaped_input = processed.reshape((1,num_electrodes*378))
      print("\nReshaped:",reshaped_input.shape)
      output = loaded_model.predict(reshaped_input)
      print("\nResult:",output)
      now = datetime.datetime.now()
      f.write("\n%s\t%s"%(str(output),str(now.isoformat())) )

      '''--------sender code-------------'''
      
      parser1 = argparse.ArgumentParser()
      parser1.add_argument("--ip", default="10.133.23.102",
      help="The ip of the OSC server")   #IP of Hololens
      parser1.add_argument("--port", type=int, default=5005,
      help="The port the OSC server is listening on")  #port number of Python
      args1 = parser1.parse_args()
      client = udp_client.SimpleUDPClient(args1.ip, args1.port)
	  
	  ##random:
      p=["Sad","Angry","Pleasant","Happy"]
      #for z in range (0,4):
      z=random.randint(0,3)
      client.send_message("/unity1",p[z])
      '''
	  #model output:
      if(output == 0):
        client.send_message("/unity1", "Sad" )
      if(output == 1):
        client.send_message("/unity1", "Angry" )
      if(output == 2):
        client.send_message("/unity1", "Pleasant" )
      if(output == 3):
        client.send_message("/unity1", "Happy" )
      '''
      

if __name__ == "__main__":
  
  parser = argparse.ArgumentParser()
  parser.add_argument("--ip",
      default="127.0.0.1", help="The ip to listen on") #IP of OpenBCI
  parser.add_argument("--port",
      type=int, default=12345, help="The port to listen on")  #Port number of OpenBCI
  args = parser.parse_args()

  dispatcher = dispatcher.Dispatcher()
  dispatcher.map("/openbci", print_handler)
  #print(type(x))
  #dispatcher.map("/volume", print_volume_handler, "Volume")
  #dispatcher.map("/logvolume", print_compute_handler, "Log volume", math.log)

  server = osc_server.ThreadingOSCUDPServer(
      (args.ip, args.port), dispatcher)
  #print("Serving on {}".format(server.server_address))
  #print(type(server) )

  

  server.serve_forever()

