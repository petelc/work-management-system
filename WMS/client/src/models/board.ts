export interface Board {
  id: number;
  requestName: string;
  votes: string;
  request: string; // I think I need to build in the request object here
  member: string; // I think I need to build in the member<Employee> object here
  change: string; // I think I need to build in the change object here
  project: string; // I think I need to build in the project object here
  createDate: string;
  isActive: boolean;
}

export interface BoardParams {
  orderBy: string;
  searchTerm?: string;
  pageNumber: number;
  pageSize: number;
}
