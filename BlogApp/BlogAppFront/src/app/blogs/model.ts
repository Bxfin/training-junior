export interface Blog {
    id?: number;
    title: string;
    category: string;
    author: string;
    datePosted?: string;
}


export interface BlogCriteria {
    page?: number;
    pageSize?: number;
    search?: string;
}

export interface PagedResult<T> {
    currentPage: number;
    pageCount: number;
    pageSize: number;
    rowCount: number;
    items: Array<T>;
}