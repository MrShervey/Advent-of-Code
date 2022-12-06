def readFile():
    calories = []
    count = 0
    f = open("Challenges 2022/1/input_data.txt","r")
    for line in f:
        data = line.split("\n")     
        if data[0] != "":
            count += int(data[0])
        else:
            calories.append(count)
            count = 0
    f.close()
    return calories

readData = readFile()
sorteddata=sorted(readData,reverse = True)
#part 1
print(sorteddata[0])
#part 2
print(sorteddata[0] + sorteddata[1] + sorteddata[2])