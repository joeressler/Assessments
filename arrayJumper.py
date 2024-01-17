def jumpDeeper(arr, distance):
    keepDex = 0
    maxSize = 0
    for i in range(1, distance + 1):
        try:
            if arr[i] >= maxSize:
                maxSize = arr[i]
                keepDex = i
        except IndexError:
            break
    if maxSize == 0:
        keepDex = distance

    return maxSize, keepDex


def jump(arr, distance):
    keepDex = 0
    finalSize = 0
    maxSize = 0
    totalSize = 0
    for i in range(1, distance+1):
        tempSize, tempDex = jumpDeeper(arr[keepDex:], arr[keepDex])
        try:
            if arr[i] >= maxSize and:
                maxSize = arr[i]
                keepDex = i
        except IndexError:
            break


    if

    if totalSize == 0:
        keepDex = distance
    finalDex = 0

    for i in range(1, distance+1):

        if jump(arr[keepDex:], arr[keepDex]) >= totalSize
    #recurseResult = jumpRecurse(arr[keepDex:], arr[keepDex])

    return keepDex


def solution(a):
    jumps = 0
    destination = 0
    arr = a.copy()

    for i in range(len(arr)):
        if i == destination and arr[i] != 0:
            jumps += 1
            destination = i + jump(arr[i:], arr[i])

        elif i == len(arr) - 1:
            if arr[i] == 0 and destination < i + 1:
                return 0
        else:
            continue

    return jumps


print(solution([2, 4, 4, 2, 2, 0, 2, 2, 1, 5, 2, 0, 2, 3, 4, 5, 0, 3, 2, 4, 3]))
