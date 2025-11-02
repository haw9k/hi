#!/bin/bash

lc_vars=$(env | grep '^LC_')
line_count=$(echo "$lc_vars" | wc -l)


if [ "$line_count" -eq 0 ]; then

        exit 0
fi

uq_vals=$(echo "$lc_vars" | awk -F '=' '{print $2}' | sort | uniq)
count=$(echo "$uq_vals" | wc -l)

if [ "$count" -gt 1 ]; then
        exit 1
else
        exit 0
fi
