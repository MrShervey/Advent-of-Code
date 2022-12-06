#Day 6 - Tuning Tables
def readfile():
    f = open("Challenges 2022/6/input.txt","r")
    data = f.readline()
    data = data.split("\n")
    splitData = data[0]
    return splitData

def findPacketMarker():
    datastream = readfile()
    front = 0
    back = 0
    flag = False
    count = 0
    while not flag and front <= len(datastream)-4:
        count = 1
        valid = True
        packetMarker = []
        while count <= 4 and valid:
            if datastream[back] not in packetMarker:
                packetMarker.append(datastream[back])
                back += 1
                count +=1
            else:
                front += 1
                back = front
                valid = False
        if len(packetMarker) == 4:
            flag = True
    return back, packetMarker

print(findPacketMarker())