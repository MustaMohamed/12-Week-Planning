import React, { FC, SyntheticEvent, useState } from 'react';
import { Container, Menu, StrictMenuItemProps } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import { RouteNames } from '../../types/routes';

const routes: string[] = Object.keys(RouteNames).filter(r => RouteNames[r] !== RouteNames.Base);
const authNavs: string[] = ['login', 'signup'];

const Navbar: FC = () => {
  const [activeItem, setActiveItem]: [string, (name: string) => void] = useState<string>(RouteNames.Home);
  const handleItemClick = (e: SyntheticEvent, { name }: StrictMenuItemProps) => setActiveItem(name || RouteNames.Home);
  return (
    <Menu pointing secondary>
      <Container fluid>
        {routes && routes.map((item, idx) =>
          <Menu.Item
            as={Link}
            to={RouteNames[item]}
            name={item}
            active={activeItem === item}
            key={idx}
            onClick={handleItemClick}
          />)
        }
        {
          authNavs && <Menu.Menu position='right'>
            {authNavs.map((item, idx) =>
              <Menu.Item
                name={item}
                active={activeItem === item}
                key={idx}
                onClick={handleItemClick}
              />)}
          </Menu.Menu>
        }
      </Container>
    </Menu>
  );
};

export default Navbar;