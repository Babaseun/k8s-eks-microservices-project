# Microservices Homelab

The purpose of this project is to learn and have fun with kubernetes.

This project consists of multiple microservices, including:

- A Node.js API
- A .NET/C# Web API

These services are fronted by a reverse proxy using Nginx.

## Database

Currently running EDB operator an implementation of cloudnativepg in the kubernetes cluster

# Kubernetes Cluster Deployment

I'm using 3 multipass instances with a controlplane and 2 worker nodes running kubernetes.

20 gigabyte disk, 2 cpu cores, 3 gigabyte for the memory.

## Monitoring

Prometheus used for metrics collection from db cluster and api's with grafana for displaying the results.
