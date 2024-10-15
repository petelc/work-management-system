import { createBrowserRouter } from 'react-router-dom';

import App from '../../layouts/App';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
  },
]);
