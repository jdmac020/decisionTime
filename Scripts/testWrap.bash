#!/bin/bash

./test.bash

i=0

while [ $? -eq 0 ]
	do
		./test.bash
		i=$((i + 1))
		echo "$i"
		if [ i -eq 2 ]
			then
				./testBreak.bash
		fi
		echo "We didn't break"
done
