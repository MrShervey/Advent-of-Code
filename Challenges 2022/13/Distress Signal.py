def readFile():
    data = []
    with open("Challenges 2022/13/inputTest.txt") as f:
        lines = f.read().splitlines()
        for x in range(len(lines)):
            if lines[x] != "":
                data.append(lines[x])
            else:
                data = []
            if len(data) == 2:
                parseData(data[0], data[1])

def parseData(lineOne, lineTwo):
    print(lineOne)
    print(lineTwo)
    


readFile()