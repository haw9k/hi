#!/bin/bash
output_file="$1"
duration="$2"

touch "$output_file"

for ((i=0;i<duration;i++));
do
    timestamp=$(date +"%d.%m.%y %H:%M")
    loadavg=$(cat /proc/loadavg)
    echo "$timestamp = $loadavg" >> "$output_file"
    sleep 1
done
