#!/bin/bash

touch logs.log

for file in /var/log/*.log; do
        tail -n 1 "$file" >> logs.log
done
