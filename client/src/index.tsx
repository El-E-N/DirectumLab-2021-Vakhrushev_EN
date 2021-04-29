import React from 'react';
import {render} from 'react-dom';
import {createBrowserHistory} from 'history';
import App from './components/app/app';
import {Router} from 'react-router-dom';
import './index.css';

export const history = createBrowserHistory();

render(
    <Router history={history}>
      <App/>
    </Router>,
    document.body
);
