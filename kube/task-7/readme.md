# Task 7

## Create full deployment for DNATrack

* Create a RabbitMQ service
  * DNS rmq
  * image
    * rabbitmq:3-management
  * Ports
    * TCP: 5672
    * TCP: 15672
  * Environment variables
    * RABBITMQ_DEFAULT_USER
      * rabbitmq
    * RABBITMQ_DEFAULT_PASS
      * rabbitmq
    * RABBITMQ_DEFAULT_VHOST
      * /
* Create a mongodb service
  * DNS mongo
  * image
    * mongo:4.0.5
  * Ports
    * TCP: 27017
* Create services and ingress for
  * WebAdmin(MAC) - edit existing config
    * arukim/dnatrack-web-client:v2
  * WebClient(MAC) - create a new one
    * arukim/dnatrack-web-admin:v2
* Create deployment for 
  * Analysis - create a new one
    * arukim/dnatrack-service-analysis:v1
  * Replica Count: 2 
* Run all and check application at http://overmind.westeurope.cloudapp.azure.com/{MAC}
* [BONUS]Create Cron Job for Validator
  * arukim/dnatrack-job-validator:v1

