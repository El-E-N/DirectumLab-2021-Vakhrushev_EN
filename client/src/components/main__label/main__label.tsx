import * as React from 'react';
import './main__label.css';

interface IProps {
  title: string;
  placeholder: string;
}

const MainLabel: React.FunctionComponent<IProps> = (props) => {
  return <label className="main__label">
    {props.title}
    <input className="main__input" type="text" name="userName" placeholder={props.placeholder}/>
  </label>;
};

export default MainLabel;
