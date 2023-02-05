def sort(a):
    for i in range(1, len(a)):
        k, j = a[i], i - 1
        while 0 <= j and a[j] > k:
            a[j + 1], j = a[j], j - 1
        a[j + 1] = k
    return a
