pipeline {
  agent any
  stages {
    stage('build') {
      steps {
        echo 'Building...'
      }
    }

    stage('Test') {
      parallel {
        stage('Testing edge') {
          steps {
            echo 'testing'
            sh 'echo "testing on edge"'
          }
        }

        stage('Testing firefox') {
          steps {
            sh 'echo "testing firefox"'
          }
        }

        stage('testing chrome') {
          steps {
            sh 'echo "testing chrome"'
          }
        }

      }
    }

    stage('deploy') {
      steps {
        echo 'deploying'
      }
    }

  }
}