#!/bin/sh
for i in {1..10} 
do 
if (curl --output /dev/null --silent --head --fail $SVC_URL)
   then
	    break       	   #Abandon the loop.
   fi    	   
sleep 1 && echo "Waiting api service to be accessible $SVC_URL" ; 
done;