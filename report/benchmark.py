import requests
import time

url = 'http://localhost:5050/Todo/Create'

# trigger lazy load
requests.get(url)
time.sleep(5)

start = time.time()

r = requests.get(url)

end = time.time()
print(round((end-start) * 1000))
