# Task 3

## Create a simple deployment

* Create a deployment
  * $kubectl apply -f .\first-deploy.yaml
* View deployment and it's content
  * $kubectl get deployment
  * $kubectl describe deployment dnatrack-first-deploy
  * $kubectl get replicaset
  * $kubectl describe replicaset dnatrack-first-deploy-replicaID
  * $kubectl get pod -o wide
  * $kubectl describe pod dnatrack-first-deploy-replicaID-podId
* Edit configuration, set replica count to 5
  * View deployment, replica, pods
* Delete deployment
  * $kubectl delete -f .\first-deploy.yaml



