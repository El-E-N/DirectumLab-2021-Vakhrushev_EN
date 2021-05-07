import React from 'react';
import {render} from 'react-dom';
import {createStore} from 'redux';
import {composeWithDevTools} from 'redux-devtools-extension';
import {Provider} from 'react-redux';
import App from './components/app/app';
import history from './services/history-service';
import {Router} from 'react-router-dom';
import {reducer} from './store/reducer';
import './index.css';


const store = createStore(reducer, composeWithDevTools());

render(
    <Provider store={store}>
      <Router history={history}>
        <App/>
      </Router>
    </Provider>,
    document.body
);
