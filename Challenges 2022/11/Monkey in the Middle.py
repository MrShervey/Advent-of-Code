array = [[[89, 84, 88, 78, 70],"old * 5",7,6,7],[[76, 62, 61, 54, 69, 60, 85],"old + 1",17,0,6],[[83, 89, 53],"old + 8",11,5,3],[[95, 94, 85, 57],"old + 4",13,0,1],[[82,98],"old + 7",19,5,2],[[69],"old + 2",2,1,3],[[82, 70, 58, 87, 59, 99, 92, 65],"old * 11",5,7,4],[[91, 53, 96, 98, 68, 82],"old * old",3,4,2]]
count = [0,0,0,0,0,0,0,0]
for round in range(20):
    for monkey in range(len(array)):
        while len(array[monkey][0]) > 0:
            calcInstr = array[monkey][1].split(" ")
            if calcInstr[2] == "old":
                worryCalc = array[monkey][0][0]
            else:
                worryCalc = int(calcInstr[2])
            if calcInstr[1] == "*":
                array[monkey][0][0] = array[monkey][0][0] * worryCalc
            elif calcInstr[1] == "+":
                array[monkey][0][0] = array[monkey][0][0] + worryCalc
            if (array[monkey][0][0] // array[monkey][2]) == 0:
                newMonkey = array[monkey][3]
                array[newMonkey][0].append(array[monkey][0][0])
                array[monkey][0].remove(array[monkey][0][0])
            else:
                newMonkey = array[monkey][4]
                array[newMonkey][0].append(array[monkey][0][0])
                array[monkey][0].remove(array[monkey][0][0])
            count[monkey] += 1

sortedCount = sorted(count, reverse=True)
monkeyBusiness = sortedCount[0] * sortedCount[1]
print(monkeyBusiness)
