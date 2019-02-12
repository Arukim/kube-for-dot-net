# Task 7

## Create full deployment for DNATrack

* Create and bind to public IP Service+Deployment
  * WebAdmin 80(MAC)
    * arukim/dnatrack-web-client:v1
  * WebClient 81(MAC)
    * arukim/dnatrack-web-admin:v1
* Create deployment for 
  * Analysis service
    * arukim/dnatrack-service-analysis
  * MongoDB
  * RabbitMQ
* Create Cron Job for Validator
  * arukim/dnatrack-job-validator:v1

