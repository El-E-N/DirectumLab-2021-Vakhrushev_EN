import * as React from 'react';

interface IInput {
  className?: string;
  type: string;
  name: string;
  value?: string;
  placeHolder?: string;
  readOnly?: boolean;
  onChange?: boolean;
}

const Input: React.FunctionComponent<IInput> = (props) => {
  return <input
    className={props.className}
    type={props.type}
    name={props.name}
    readOnly={props.readOnly}
    defaultValue={props.value}
    placeholder={props.placeHolder}
  />;
};

export default Input;
