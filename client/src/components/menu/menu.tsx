import * as React from 'react';
import Players from '../players/players';
import './menu.css';

const names = ['test',
  'test 2',
  'test 3',
  'test 4'
];

const Menu: React.FunctionComponent = () => {
  return <div className="menu">
    <span className="menu__header">Story voting completed</span>
    <h3 className="menu__title">Players:</h3>
    <Players names={names}/>
    <button className="menu__button">Finish voting</button>
    <span className="menu__link-name">Invite a teammate</span>
    <input className="menu__link" type="text" readOnly={true} value="https://www.planitpoker.com/board"/>
  </div>;
};

export default Menu;
