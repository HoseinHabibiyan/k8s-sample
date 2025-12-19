# ☸️ K8s-Sample: Deployment with Kind & Helm

This repository provides a streamlined example of how to containerize an application and deploy it to a local **Kubernetes** cluster using **Kind** (Kubernetes IN Docker) and **Helm**.

---

## 🛠 Prerequisites

Ensure you have the following tools installed:
* [Docker](https://www.docker.com/)
* [Kind](https://kind.sigs.k8s.io/)
* [Helm](https://helm.sh/)
* [Kubectl](https://kubernetes.io/docs/tasks/tools/)

---

## 📂 Project Structure
```text

├── src
├── myapp-chart/          # Helm Chart directory
│   ├── templates/        # Kubernetes manifest templates
│   ├── Chart.yaml        # Chart metadata
│   └── values.yaml       # Default configuration values
├── Dockerfile            # Application containerization
└── README.md
```

### 1. Create a Kind Cluster
```bash
kind create cluster --name kind-myapp
```
### 2. Build the Docker Image
```bash
docker build . -t myapp
```

### 3. Load Image into Kind
###### Note: Since Kind runs locally, it cannot pull images from Docker Hub unless they are public. You must manually load your local image into the Kind nodes:
```bash
kind load docker-image myapp --name kind-myapp
```

### 4. Deploy app using Helm
```bash
helm install myapp ./myapp-chart
```

### 5. Access the Application
#### To access app from your local machine, use port-forwarding to map the service port:
```bash
kubectl port-forward svc/myapp 8080:80
```
