#!/bin/bash
path="$1"

if [ ! -d "$path" ]; then
    exit 1
fi

for dir in "$path"/*/; do
    if [ -d "$dir" ];then
        dirname=$(basename "$dir")
        elements_count=$(ls -A "$dir" | wc -l)
        echo "$elements_count" > "${dirname}.txt"
    fi
done
