import * as React from 'react';
import Players from '../players/players';
import Button from '../button/button';
import Input from '../input/input';
import EnterStory from '../enter-story/enter-story';
import './menu.css';

const names = ['test',
  'test 2',
  'test 3',
  'test 4'
];

interface IProps {
  addEnter?: boolean;
  onClick?(): void;
}

const Menu: React.FunctionComponent<IProps> = (props) => {
  return <div className="menu">
    <span className="menu__header">Story voting completed</span>
    <h3 className="menu__title">Players:</h3>
    <Players names={names}/>
    {props.addEnter ? <EnterStory/> : <Button className={'menu__button'} value={'Finish voting'} onClick={props.onClick}/>}
    <span className="menu__link-name">Invite a teammate</span>
    <Input
      className={'menu__link'}
      type={'text'}
      name={'menuLink'}
      readOnly
      value={window.location.href}
    />
  </div>;
};

export default Menu;
