import axios, { AxiosResponse, AxiosError } from 'axios';
import { toast } from 'react-toastify';

import { router } from '../helpers/router/Routes';
import { PaginatedResponse } from '../models/pagination';
import { store } from '../store/configureStore';
//import { store } from '../store/configureStore';

const sleep = () => new Promise((resolve) => setTimeout(resolve, 500));

axios.defaults.baseURL = import.meta.env.VITE_API_URL;
axios.defaults.withCredentials = true;

const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.request.use((config) => {
  const token = store.getState().account.user?.token;
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

axios.interceptors.response.use(
  async (response) => {
    if (import.meta.env.DEV) await sleep();
    const pagination = response.headers['pagination'];
    if (pagination) {
      response.data = new PaginatedResponse(
        response.data,
        JSON.parse(pagination)
      );
      return response;
    }
    return response;
  },
  (error: AxiosError) => {
    const { data, status } = error.response as AxiosResponse;
    switch (status) {
      case 400:
        if (data.errors) {
          const modelStateErrors: string[] = [];
          for (const key in data.errors) {
            if (data.errors[key]) {
              modelStateErrors.push(data.errors[key]);
            }
          }
          throw modelStateErrors.flat();
        }
        toast.error(data.title);
        break;
      case 401:
        toast.error(data.title);
        break;
      case 403:
        toast.error('You are not allowed to do that!');
        break;
      case 500:
        router.navigate('/server-error', { state: { error: data } });
        break;
      default:
        break;
    }
    return Promise.reject(error.response);
  }
);

const requests = {
  get: (url: string, params?: URLSearchParams) =>
    axios.get(url, { params }).then(responseBody),
  post: (url: string, body: object) => axios.post(url, body).then(responseBody),
  put: (url: string, body: object) => axios.put(url, body).then(responseBody),
  del: (url: string) => axios.delete(url).then(responseBody),
  postForm: (url: string, data: FormData) =>
    axios
      .post(url, data, {
        headers: { 'Content-type': 'multipart/form-data' },
      })
      .then(responseBody),
  putForm: (url: string, data: FormData) =>
    axios
      .put(url, data, {
        headers: { 'Content-type': 'multipart/form-data' },
      })
      .then(responseBody),
};

const requestTypes = {
  get: (url: string) => axios.get(url).then(responseBody),
};

const requestCounts = {
  get: (url: string) => axios.get(url).then(responseBody),
};

// function createFormData(item: any) {
//   const formData = new FormData();
//   for (const key in item) {
//     formData.append(key, item[key]);
//   }
//   return formData;
// }

const UserRequest = {
  list: (params: URLSearchParams) => requests.get('requests', params),
  create: (values: any) => requests.post('requests/create', values),
  approve: (values: any) => requests.put('requests/approve', values),
  setType: (values: any) => requests.put('requests/set-type', values),
  details: (id: number) => requests.get(`request/${id}`),
  fetchFilters: () => requests.get('requests/filters'),
};

const Account = {
  login: (values: any) => requests.post('account/login', values),
  register: (values: any) => requests.post('account/register', values),
  currentUser: () => requests.get('account/fetchCurrentUser'),
  //allUsers: () => requests.get('account/fetchAllUsers'),
  fetchAddress: () => requests.get('account/savedAddress'),
};

const Type = {
  fetchTypes: () => requestTypes.get('requests/types'),
};

const RequestCounts = {
  list: () => requestCounts.get('dashboard/req_count'),
};

const Requestor = {
  allUsers: () => requests.get('account/fetchAllUsers'),
};

const agent = {
  UserRequest,
  Account,
  Type,
  RequestCounts,
  Requestor,
};

export default agent;
