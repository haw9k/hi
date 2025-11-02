
#!/bin/bash
planet="$1"

if [ "$planet" = "Mercury" ]; then
        echo "0"
        exit
fi
if [ "$planet" = "Venus" ]; then
        echo "0"
        exit
fi
if [ "$planet" = "Mars" ]; then
        echo "2"
        exit
fi
if [ "$planet" = "Jupiter" ]; then
        echo "98"
        exit
fi
if [ "$planet" = "Saturn" ]; then
        echo "83"
        exit
fi
if [ "$planet" = "Uranus" ]; then
        echo "27"
        exit
fi
if [ "$planet" = "Neptune" ]; then
        echo "14"
        exit
fi
if [ "$planet" = "Earth" ]; then
        echo "1"
        exit
fi

echo "Unknown planet"
