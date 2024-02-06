import { Place, Work } from '@mui/icons-material'
import { Avatar, Button, Grid } from '@mui/material'
import Services from './services'
import { convertCategory } from '../AcceptedCard'

type InvitedCardsProps = {
  name: string
  createdAt: Date
  suburb: string
  category: number
  id: number
  description: string
  price: number
}

export function InvitedCard({
  category,
  createdAt,
  description,
  id,
  name,
  suburb,
  price,
}: InvitedCardsProps) {
  function stringToColor(string: string) {
    let hash = 0
    let i

    /* eslint-disable no-bitwise */
    for (i = 0; i < string.length; i += 1) {
      hash = string.charCodeAt(i) + ((hash << 5) - hash)
    }

    let color = '#'

    for (i = 0; i < 3; i += 1) {
      const value = (hash >> (i * 8)) & 0xff
      color += `00${value.toString(16)}`.slice(-2)
    }
    /* eslint-enable no-bitwise */

    return color
  }

  function stringAvatar(name: string) {
    const newName =
      name.split(' ').length > 1
        ? `${name[0]}${name.split(' ')[name.split(' ').length - 1][0]}`
        : `${name[0]}`

    return {
      sx: {
        bgcolor: stringToColor(name),
      },
      children: newName,
    }
  }

  async function handleUpdate(status: number) {
    const services = new Services()

    const approved = status === 1

    const { error } = await services.Update({ id, approved })

    if (!error) {
      console.log('deu certo')
    }
  }

  return (
    <Grid
      container
      style={{
        height: 350,
        background: 'white',
      }}
    >
      <Grid
        item
        xs={12}
        style={{
          maxHeight: '15%',
          marginTop: '10px',
          marginBottom: '10px',
          paddingBottom: '10px',
        }}
      >
        <Grid
          container
          style={{
            paddingBottom: '5px',
            borderBottom: '1px solid #0000008c',
          }}
        >
          <Grid
            item
            xs={2}
            style={{
              alignContent: 'center',
              display: 'flex',
              justifyContent: 'center',
              alignSelf: 'center',
            }}
          >
            <Avatar {...stringAvatar(name)} />
          </Grid>
          <Grid item xs={10}>
            <Grid container>
              <Grid item xs={12}>
                {name}
              </Grid>
              <Grid item xs={12}>
                {new Date(createdAt).toDateString()}
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
      <Grid item xs={12} style={{ borderBottom: '1px solid #0000008c' }}>
        <Grid
          container
          style={{
            marginTop: '10px',
            marginBottom: '10px',
          }}
        >
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            <Place />
            {suburb}
          </Grid>
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            <Work /> {convertCategory(category)}
          </Grid>
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              display: 'flex',
              alignItems: 'center',
            }}
          >
            Job ID: {id}
          </Grid>
        </Grid>
      </Grid>
      <Grid
        item
        xs={12}
        style={{ minHeight: '40%', borderBottom: '1px solid #0000008c' }}
      >
        <p style={{ padding: '10px' }}>{description}</p>
      </Grid>
      <Grid item xs={12} style={{ height: '15%', display: 'flex' }}>
        <Grid
          container
          style={{ justifyContent: 'center', alignSelf: 'center' }}
        >
          <Grid item xs={1} style={{ maxHeight: '10%' }} />
          <Grid item xs={2} style={{ maxHeight: '10%' }}>
            <Button
              variant="contained"
              color="primary"
              fullWidth
              onClick={() => handleUpdate(1)}
            >
              Accept
            </Button>
          </Grid>
          <Grid item xs={1} style={{ maxHeight: '10%' }} />
          <Grid item xs={2} style={{ maxHeight: '10%' }}>
            <Button
              variant="contained"
              color="inherit"
              title="teste"
              fullWidth
              style={{ color: 'black' }}
              onClick={() => handleUpdate(2)}
            >
              Decline
            </Button>
          </Grid>
          <Grid
            item
            xs={4}
            style={{
              maxHeight: '10%',
              alignSelf: 'center',
              textAlign: 'center',
            }}
          >
            ${price} Lead Invitation
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  )
}
