def sort(a):
    if len(a) <= 1:
        return a

    mid = int(len(a) / 2)
    l, r = sort(a[:mid]), sort(a[mid:])
    i = j = 0
    result = []
    while i < len(l) and j < len(r):
        if l[i] < r[j]:
            result.append(l[i])
            i += 1
        else:
            result.append(r[j])
            j += 1
    return result + l[i:] + r[j:]