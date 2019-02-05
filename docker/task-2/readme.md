# Docker Task #2

Build and run your own container, yo ho ho.

## Task

### Building an image

- Get .NET sources (src folder in repository)
- Open src folder in VSCode
- Navigate to 'src' folder 
  - use either separate terminal or VS code internal
- Study contents of the \DNATrack.Web.Admin\Dockerfile file
- Build Web.Admin service image
  - $docker build -t dnatrack/web/admin -f .\DNATrack.Web.Admin\Dockerfile .
    - 'dnatrack/web/admin' - image name
    - '-f .\DNATrack.Web.Admin\Dockerfile' - path to Dockerfile
    - '.' - work folder
  - $docker images
  - run build again

### Running .NET Core App

- Try to run app
  - $docker run dnatrack/web/admin
- Any ideas how to pass missing params?
- Passing Environment variables using -e 
  -  Rabbit:Endpoint="rabbitmq://localhost:5672"
- Run two times
  - $docker ps
- Remove old
  - $docker stop
  - $docker ps -a
  - $docker rm 
  - $docker run -rm
- We also need a port
  - -p 8000:80
  - browse
  - run twice
  - delete old

### We need a RabbitMQ
- https://www.rabbitmq.com/download.html
- docker run -p "5672:5672" -e RABBITMQ_DEFAULT_USER="rabbitmq" -e RABBITMQ_DEFAULT_PASS="rabbitmq" rabbitmq:3-management


### Connectivity
- run again application
- host.docker.internal
- Rabbit:Password="rabbitmq"
- Rabbit:Password="rabbitmq"


### Finally, anyone?







### Some magic
- $docker rm $(docker stop $(docker ps -a -q -f ancestor=dnatrack/web/admin))
