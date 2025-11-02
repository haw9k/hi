#!/bin/bash

set -euo pipefail

IFS=":" read -ra dirs <<< "$PATH"

for dir in "${dirs[@]}"; do
        if [ -d "$dir" ]; then
                count=$(find "$dir" -maxdepth 1 -type f 2>/dev/null | wc -l)
                echo "$dir => $count"
        fi
done
