import { createContext, ReactNode, useContext, useState } from 'react'
import Services, { IJob } from './services'

export type JobContextProps = {
  jobs: IJob[]
  GetJobs: (status: number) => void
}

export type JobContextProviderProps = {
  children: ReactNode
}

export const JobContext = createContext<JobContextProps>({} as JobContextProps)

export const JobProvider = ({ children }: JobContextProviderProps) => {
  const [jobs, setJobs] = useState<IJob[] | []>([])

  const GetJobs = async (status: number) => {
    const services = new Services()
    const { error, response } = await services.GetByStatus(status.toString())
    console.log(response)
    if (!error && response) setJobs(response)
  }

  return (
    <JobContext.Provider
      value={{
        jobs,
        GetJobs,
      }}
    >
      {children}
    </JobContext.Provider>
  )
}

export function useJob(): JobContextProps {
  const context = useContext(JobContext)

  if (!context) {
    throw new Error('useExample must be used within an JobProvider')
  }
  return context
}
