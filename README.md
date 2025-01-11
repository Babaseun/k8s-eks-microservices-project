# Microservices Homelab

This project consists of multiple microservices, including:

- A Node.js API
- A .NET/C# Web API

These services are fronted by a reverse proxy using Nginx.

## Database

Currently running EDB operator an implementation of cloudnativepg in the kubernetes cluster

# Kubernetes Cluster Deployment Script

I included a bash script automates the deployment of a Kubernetes cluster on local virtual machines (VMs) using Multipass. Here’s a summary of its key functions:

## Overview

### Purpose

- Deploys a control plane and worker nodes to form a Kubernetes cluster.
- Supports two deployment modes:
  - **BRIDGE (default)**: Places VMs on the local network (accessible externally).
  - **NAT**: Places VMs in a private virtual network (requires port forwarding for external access).
- **Dynamic Resource Allocation**: Adjusts the number of worker nodes and VM memory based on available system RAM.

## Key Steps

### Pre-checks

- Ensures `jq` and `multipass` are installed. If missing, the script exits with installation instructions.
- Validates system RAM:
  - Less than 8GB: Exits (insufficient memory).
  - 8GB to 15GB: Limits cluster to one worker node (2GB RAM each).
  - 16GB or more: Deploys two worker nodes (3GB RAM each).

### Network Configuration

- Attempts to configure a bridged network by detecting the default network interface.
- Falls back to NAT if no suitable interface is found.

### Cluster Reset (if VMs exist)

- If VMs (control plane or nodes) already exist, prompts the user to delete and rebuild them.

### VM Deployment

- Launches VMs (control plane and worker nodes) with specified CPU, disk, and memory configurations.
- Verifies that each VM boots successfully.

### Host Configuration

- Sets hostnames and updates the `/etc/hosts` file on each VM.
- Transfers setup scripts to VMs for further configuration.

### Automated Setup (Optional)

- If the script is run with the `-auto` flag:
  - Transfers and executes scripts to install Kubernetes components (kernel setup, container runtime, etc.).
  - Deploys the control plane.
  - Configures worker nodes to join the cluster.
