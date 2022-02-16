def sort(a):
    if len(a) <= 1:
        return a
    h, *t = a
    return sort([x for x in t if x < h]) + [h] + sort([x for x in t if x >= h])
