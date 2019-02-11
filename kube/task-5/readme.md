# Task 5

## Create an advanced deployment

* Create a deployment
  * $kubectl apply -f .\admin-deploy.yaml
* Check information about pod
  * $kubectl get pod
  * $kubectl get pod -o wide
  * $kubectl logs {} --timestamps=true
  * $kubectl describe pod {}
* View information about pods
  * $kubectl top pod
* Delete deployment
  * $kubectl delete -f ./