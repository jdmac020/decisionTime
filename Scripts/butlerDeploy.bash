#!/bin/bash

curl -L -o butler.zip https://broth.itch.ovh/butler/linux-amd64/LATEST/archive/default

while [ $? -eq 0 ]
	do
		unzip butler.zip
		i=$i+1
		chmod +x butler
done

if [ $? = 0 ]
	then
		unzip butler.zip
	else
		exit 1
fi

if [ $? = 0 ]
	then
		chmod +x butler
	else
		exit 1
fi

if [ $? = 0 ]
	then
		./butler -V
	else
		exit 1
fi

if [ $? = 0 ]
	then
		./butler push DecisionTimeDemo-Win.zip jdmac020/decision-time:windows10
	else
		exit 1
fi