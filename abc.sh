docker run --rm  -u root  -p 8080:8080 -p 50000:50000 \
    -e 'JAVA_OPTS=-Dhudson.TcpSlaveAgentListener.hostName=192.168.1.118' \
    -v jenkins@ids:/var/cloudbees-jenkins-distribution  \
    -v /var/run/docker.sock:/var/run/docker.sock \
    cloudbees/cloudbees-jenkins-distribution