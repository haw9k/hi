#!/bin/bash
set -euo pipefail
old_files=$(ls -A)


if [ "${BAR:-}" = "1" ]; then
    exit 1234
fi

if [ -f "./fix.txt" ]; then
        echo "file detected";
        exit
fi

while true; do
        cur_files=$(ls -A)
        if [[ "$cur_files" != "$old_files" ]]; then
                echo "operation detected";
                break
        fi
done
