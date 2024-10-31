import { createBrowserRouter } from 'react-router-dom';

import App from '../../layouts/App';
import RequestPage from '../../pages/request/RequestPage';
import Request from '../../pages/request/Request';

import Login from '../../pages/account/Login';
import RequireAuth from './RequiredAuth';
import Register from '../../pages/account/Register';

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
      { path: '/register', element: <Register /> },
    ],
  },
]);
