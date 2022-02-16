from heapq import heappop, heappush


def sort(a):
    heap = []
    for e in a:
        heappush(heap, e)

    result = []
    while heap:
        e = heappop(heap)
        result.append(e)

    return result
