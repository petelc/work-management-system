import { createBrowserRouter } from 'react-router-dom';

import App from '../../layouts/App';
import RequestPage from '../../pages/request/RequestPage';
import Request from '../../pages/request/Request';
//import RequireAuth from './RequiredAuth';
import Login from '../../pages/account/Login';
import RequireAuth from './RequiredAuth';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      {
        element: <RequireAuth />,
        children: [{ path: 'requests', element: <Request /> }],
      },
      { path: 'request', element: <RequestPage /> },
      { path: '/login', element: <Login /> },
    ],
  },
]);
