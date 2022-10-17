#!/bin/bash

# Build, deploy, and manage
# https://fsymbols.com/es/generadores/tarty/

# iniciar con sudo o entrar con su root
# ░██████╗██╗░░░██╗██████╗░░█████╗░
# ██╔════╝██║░░░██║██╔══██╗██╔══██╗
# ╚█████╗░██║░░░██║██║░░██║██║░░██║
# ░╚═══██╗██║░░░██║██║░░██║██║░░██║
# ██████╔╝╚██████╔╝██████╔╝╚█████╔╝
# ╚═════╝░░╚═════╝░╚═════╝░░╚════╝░
# sudo ./deploy.sh

docker build -t jwt-image-ofi-1 -f Dockerfile .
docker run -d -p 84:80 --name jwt-contenedor-ofi-1 jwt-image-ofi-1
docker images
docker ps -a

# http://192.168.0.9:5080/api/user-posts