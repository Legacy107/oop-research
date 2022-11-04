import requests
import time

# url = 'http://localhost:5050/Todo/Create'
url = 'http://localhost:22152/Todolist/Create'

# trigger lazy load
requests.get(url)
time.sleep(5)

start = time.time()

r = requests.get(url)

end = time.time()
print(round((end-start) * 1000))


# import requests
# import time

# url = 'http://localhost:5050/Todo/Create'
# # url = 'http://localhost:22152/Todolist/Create'
# sum = 0
# n = 10

# for i in range(n):
#     start = time.time()

#     r = requests.get(url)
    
#     # os.sleep(1)
    
#     end = time.time()
#     print(round((end-start) * 1000))
#     sum += end - start

# print((sum / n) * 1000)