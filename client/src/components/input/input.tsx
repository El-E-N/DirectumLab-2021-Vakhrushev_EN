import * as React from 'react';

interface IProps {
  className?: string;
  type: string;
  name: string;
  value?: string;
  placeHolder?: string;
  readOnly?: boolean;
  id?: string;
  // eslint-disable-next-line no-unused-vars
  onChange?(evt: React.ChangeEvent<HTMLInputElement>): void;
  onClick?(): void;
}

class Input extends React.Component<IProps, {}> {
  render() {
    return <input
      id={this.props.id}
      className={this.props.className}
      type={this.props.type}
      name={this.props.name}
      readOnly={this.props.readOnly}
      defaultValue={this.props.value}
      placeholder={this.props.placeHolder}
      onChange={this.props.onChange}
      onClick={this.props.onClick}
    />;
  }
}

export default Input;