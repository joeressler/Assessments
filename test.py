
def solution(times):
    idCheckTime = 300
    queue = []
    finishList = []
    processEndTime = 0
    leftList = []
    process = False

    queue.append([times[0], times[0] + idCheckTime, "processing"])
    times = times[1:]

    for i in times:
        for foo in queue.copy():
            if foo[1] < i:
                finishList.append(foo[1])
                queue.remove(foo)
        if len(queue) > 0:
            queue[0][2] = "processing"
        if len(queue) == 0:
            queue.append([i, i + idCheckTime, "processing"])
        else:
            toProcessCount = 0
            for n in queue:
                if n[2] == "toProcess":
                    toProcessCount += 1
            if toProcessCount > 10:
                queue.append([i, i, "left"])
            else:
                foundIt = False
                for q in range(0, len(queue)):
                    x = queue[len(queue) - q - 1]
                    if x[2] == "toProcess" or x[2] == "processing":
                        queue.append([i, x[1] + idCheckTime, "toProcess"])
                        foundIt = True
                        break
                if not foundIt:
                    queue.append([i, i + idCheckTime, "processing"])
    for foo in queue:
        finishList.append(foo[1])
    return finishList


t = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]

print(solution(t))






