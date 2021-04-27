import * as React from 'react';
import Input from '../input/input';
import './main__label.css';

interface IProps {
  title: string;
  placeHolder: string;
  name: string;
  id?: string;
}

const MainLabel: React.FunctionComponent<IProps> = (props) => {
  return <label className="main__label">
    {props.title}
    <Input
      id={props.id}
      className={'main__input'}
      type={'text'}
      name={props.name}
      placeHolder={props.placeHolder}
    />
  </label>;
};

export default MainLabel;
