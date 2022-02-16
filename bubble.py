def sort(a):
    N, swapped = len(a), True
    while swapped:
        N, swapped = N - 1, False
        for i in range(N):
            if a[i] > a[i + 1]:
                a[i], a[i + 1], swapped = a[i + 1], a[i], True
    return a
