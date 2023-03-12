const ##Class##s = {
    list: () => requests.get<##Class##[]>(`/##Class##s`),
    details: (id: string) => requests.get<##Class##>(`/##Class##s/${id}`),
    create: (item: ##Class##) => {
        const { id: _, ...New##Class## } = item;
        var res = requests.post<number>(`/##Class##s`, New##Class## )
        return res
    },
    update: (item: ##Class##) => requests.put<void>(`/##Class##s/${item.id}`, item),
    delete: (id: string) => requests.del<void>(`/##Class##s/${id}`)
}