# Microservice Demo

This is a demo for two microservices with deployment into kubernetes.

### **Microservice 1**

 - A web api built with aspnet core and SQL Server as a DBMS.
 - The web api will manage platforms (create, get by id and get all
   platforms)

### **Microservice 2**

 - A web api built with aspnet core and SQL Server as a DBMS.

 - The web api will manage the command lines associated with these
   platforms.

## Repository folders description :

 1. **PlateformService** : microservice using aspnet core web api dotnet 5 
 2. **CommandsService** : microservice using aspnet core web api dotnet 5
 3. **K8S** : Deployment files for kubernetes.

## Using Docker Images

All docker images in this repository are prefixed with my own dockerhub id
if you want to build images, you can change the image name and also you can push it to your dockerhub using **<dockerhubid/imagename>**
Caution : if you change the hole image name you must change also the deployment file in the kubernetes files (cf : K8S)

## Kubernetes

To Deploy a docker image in a kubernetes pod using the deployment files  you must push the image to your own docker hub or use the these generated already in my dockerhub profile.

Command line to deploy the platform microservice to a k8s pod :

    kubectl apply -f platform-depl.yml

Check the created deployment ;

    kubectl get deployments

Check pods :

    kubectl get pods

check services and ports :

    kubectl get services

### TODO :

 - [ ] Finalize the two microservices.
 - [ ] Add gRPC sync communication.
 - [ ] Add Async communication using Event Bus
       ([RaabitMQ](https://www.rabbitmq.com/))
 - [ ] Add a gRPC service inside the plateform microservice
 - [ ] Add ingress controller
       ([ingress-nginx](https://kubernetes.github.io/ingress-nginx/deploy/))
       and the Ingress resource see
       [ingress-resource](https://kubernetes.io/docs/concepts/services-networking/ingress/)
