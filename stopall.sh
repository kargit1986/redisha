#/bin/bash

redis-cli -p 7000 shutdown
redis-cli -p 7001 shutdown
redis-cli -p 26379 shutdown


