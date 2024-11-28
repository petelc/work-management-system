import { createBrowserRouter } from 'react-router-dom';

import App from '../../App';
import RequestPage from '../../pages/request/RequestPage';
import Request from '../../pages/request/Request';

import Login from '../../pages/account/Login';
//import RequireAuth from './RequiredAuth';
import Register from '../../pages/account/Register';
import RequestDetails from '../../components/requests/RequestDetails';

import Dashboard from '../../layouts/Dashboard';
import MainGrid from '../../pages/dashboard/MainGrid';
import RequireAuth from './RequiredAuth';

export const router = createBrowserRouter([
  {
    Component: App,
    children: [
      {
        path: '/',
        Component: Dashboard,
        children: [
          {
            element: <RequireAuth />,
            children: [
              { path: '/', element: <MainGrid /> },
              { path: 'request', element: <RequestPage /> },
              { path: 'requests', element: <Request /> },
              { path: 'requests/:id', element: <RequestDetails /> },
            ],
          },
        ],
      },
      { path: '/login', element: <Login /> },
      { path: '/register', element: <Register /> },
    ],
  },
]);
